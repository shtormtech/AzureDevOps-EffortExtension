import * as React from "react";
import { showRootComponent } from "../Common";

import "./WorkItemTimeTab.scss";
/*
import * as SDK from "azure-devops-extension-sdk";
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

import { WorkItemTypeClass } from "TFS/WorkItemTracking/ProcessContracts";
*/
import {ChildWIListComponent} from "./components/ChildWI/ChildWIListComponent";
import {TimesheetForm} from "./components/Timesheet/timesheetForm";
import {activityType} from "./components/Timesheet/common/interfaces"

class WorkItemTimeTabContent extends React.Component<{}, {isModalOpen: boolean}> {

//private workItemIdValue = new ObservableValue("1");
//private workItemTypeValue = new ObservableValue("Bug");
/*
public componentDidMount() {
    SDK.init();
}
*/
constructor(props: any){
    super(props);

    this.state = {isModalOpen: false};
}

public render(): JSX.Element {

    const TS = {user: {
                    id: 0,
                    email: "",
                    name: "",
                    imageUrl: "",
                    profileUrl: ""
                },
                date: null,
                WIdi: null,
                duration: 0,
                comment: "",
                activity: activityType.Development
            };

    return (
        <div>
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
                        <ChildWIListComponent/>
                    </div>
                    <div id='WorkBloc' className='dcell'>
                        <div id='WorkTeam' className='drow'>
                            WorkTeam
                            <button onClick={() => this.openModal()}>Open modal</button>
                            <TimesheetForm
                            item={TS}
                            isOpen={this.state.isModalOpen}
                            onClose={() => this.closeModal()}
                            />
                        </div>
                        <div id='WorkType' className='drow'>
                            WorkType <br/><br/><br/><br/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

openModal() {
    this.setState({ isModalOpen: true });
}

closeModal() {
    this.setState({ isModalOpen: false });
}


/*
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
*/
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