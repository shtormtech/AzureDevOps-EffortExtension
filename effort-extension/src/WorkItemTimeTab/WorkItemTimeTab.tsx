import * as React from "react";
import * as SDK from "azure-devops-extension-sdk";

import "./WorkItemTimeTab.scss";

import { Button } from "azure-devops-ui/Button";
import { ObservableValue } from "azure-devops-ui/Core/Observable";
import { localeIgnoreCaseComparer } from "azure-devops-ui/Core/Util/String";
import { VssDetailsList } from "azure-devops-ui/VssDetailsList";
import { Header } from "azure-devops-ui/Header";
import { Page } from "azure-devops-ui/Page";
import { PickListDropdown } from "azure-devops-ui/PickList";
import { TextField } from "azure-devops-ui/TextField";

import { CommonServiceIds, getClient, IProjectPageService } from "azure-devops-extension-api";
import { IWorkItemFormNavigationService, WorkItemTrackingRestClient, WorkItemTrackingServiceIds } from "azure-devops-extension-api/WorkItemTracking";

import { showRootComponent } from "../Common";

class WorkItemTimeTabContent extends React.Component<{}, {}> {

    private workItemIdValue = new ObservableValue("1");
    private workItemTypeValue = new ObservableValue("Bug");

    public componentDidMount() {
        SDK.init();
    }

    public render(): JSX.Element {
        let resultSection: JSX.Element = this._getWorkItemsList();
        return (
            <Page className="sample-hub flex-grow">
                <Header title="Work Item Open Sample" />

                <div id='main_wrapper' className='dtable'>
                <div id='control_panel_wrapper' className='drow'>
                    <div id='TotalTime' className='dcell'>TotalTime</div>
                    <div id='D_Cell_2' className='dcell'>Manager marketing</div>
                    <div id='AddTime' className='dcell'>AddTime</div>
                    <div id='Cell_R' className='dcell'></div>
                </div>
            </div>
            <div className='dtable'>
                <div id='bottom_wrapper' className='drow'>
                    <div id='ChildWorkItemList' className='dcell'>ChildWorkItemList
                        {resultSection}
                    </div>
                    <div id='WorkBloc' className='dcell'>
                        <div id='WorkTeam' className='drow'>WorkTeam <br/><br/><br/><br/><br/><br/><br/><br/> </div>
                        <div id='WorkType' className='drow'>WorkType
                        <div className="page-content">
                        <div className="sample-form-section flex-row flex-center">
                            <TextField className="sample-work-item-id-input" label="Existing work item id" value={this.workItemIdValue} onChange={(ev, newValue) => { this.workItemIdValue.value = newValue; }} />
                            <Button className="sample-work-item-button" text="Open..." onClick={() => this.onOpenExistingWorkItemClick()} />
                        </div>
                        <div className="sample-form-section flex-row flex-center">
                            <div className="flex-column">
                                <label htmlFor="work-item-type-picker">New work item type:</label>
                                <PickListDropdown
                                    id="work-item-type-picker"
                                    className="sample-work-item-type-picker"
                                    initiallySelectedItems={[ this.workItemTypeValue.value ]}
                                    getPickListItems={() => this.getWorkItemTypes()}
                                    onSelectionChanged={(selection) => { this.workItemTypeValue.value = selection.selectedItems[0] }}
                                />
                            </div>
                            <Button className="sample-work-item-button" text="New..." onClick={() => this.onOpenNewWorkItemClick()} />
                    </div>
                </div>

                    </div>
                    </div>
                </div>
            </div>
            

            </Page>
        );
    }

    private async getWorkItemTypes(): Promise<string[]> {

        const projectService = await SDK.getService<IProjectPageService>(CommonServiceIds.ProjectPageService);
        const project = await projectService.getProject();

        if (!project) {
            return [ "Bug" ];
        }

        const client = getClient(WorkItemTrackingRestClient);
        return client.getWorkItemTypes(project.name).then(types => {
            const typeNames = types.map(t => t.name);
            typeNames.sort((a, b) => localeIgnoreCaseComparer(a, b));
            return typeNames;
        });
    }

    private async onOpenExistingWorkItemClick() {
        const navSvc = await SDK.getService<IWorkItemFormNavigationService>(WorkItemTrackingServiceIds.WorkItemFormNavigationService);
        navSvc.openWorkItem(parseInt(this.workItemIdValue.value));
    };

    private async onOpenNewWorkItemClick() {
        const navSvc = await SDK.getService<IWorkItemFormNavigationService>(WorkItemTrackingServiceIds.WorkItemFormNavigationService);
        navSvc.openNewWorkItem(this.workItemTypeValue.value, { 
            Title: "Opened a work item from the Work Item Nav Service",
            Tags: "extension;wit-service",
            priority: 1,
            "System.AssignedTo": SDK.getUser().name,
         });
    };


    private _getWorkItemsList(): JSX.Element {
        //let columns = queryResult.columns.map((c, i) => { return { key: c.referenceName, name: c.name, fieldName: c.referenceName, minWidth: this._widths[i] } });
        
        const columns: IColumn[] = [
            {
                key: "name",
                name: "name",
                fieldName:"",
                minWidth:5,
                maxWidth: 6
            },
            {
                key: "value",
                name: "value",
                fieldName:"",
                minWidth:5,
                maxWidth: 6
            },
            {
                key: "size",
                name: "size",
                fieldName:"",
                minWidth:5,
                maxWidth: 6
            },
        ];

        let items: IItem[] = [
            {
                name: "item1",
                value: "item1",
                size: "10" 
            },
            {
                name: "item2",
                value: "item2",
                size: "20" 
             },{
                name: "item3",
                value: "item3",
                size: "30" 
             }
        ];

        return <VssDetailsList
            //columns={columns}
            items={items}
            setKey='set'/>
    } 
    
}
  
export interface IItem {
    name: string;
    value: string;
    size: string;
  }

export interface IColumn {
    /**
     * A unique key for identifying the column.
     */
    key: string;
  
    /**
     * Name to render on the column header.
     */
    name: string;
    /**
     * The field to pull the text value from for the column. This can be null if a custom
     * onRender method is provided.
     */
    fieldName: string;
    /**
     * Minimum width for the column.
     */
    minWidth: number;    
    /**
    * Maximum width for the column, if stretching is allowed in justified scenarios.
    */
   maxWidth?: number;
}

showRootComponent(<WorkItemTimeTabContent />);