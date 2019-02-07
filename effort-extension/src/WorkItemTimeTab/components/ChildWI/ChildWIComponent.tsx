import * as React from "react";
import "bootstrap/dist/css/bootstrap.css"
import { WorkItem } from "TFS/WorkItemTracking/Contracts";
import { IWorkItem } from "./IWorkItem"

export enum WIType{
    bag,
    task,
    epic,
    userstory
}

interface IWIChid{
    item: WorkItem;
}

export class ChildWIComponent extends React.Component<IWIChid> {    
    constructor(props: IWIChid) {
        super(props);
    }

    public render(): JSX.Element {
        const wi = this.props.item;
        console.log("------", this.props);
        return( 
            <div className="container" >
            <table>
                <tr>
                    <td>{wi.fields["System.WorkItemType"]}</td>
                    <td>(<a href={wi.url}>#{wi.id}</a>){wi.fields["System.Title"]}</td>
                    <td>{wi.rev}</td>
                </tr>    
            </table>
                <div className="row">
                    <div className="col-1">{wi.fields["System.WorkItemType"]}</div>
                    <div className="col-sm" >(<a href={wi.url}>#{wi.id}</a>){wi.fields["System.Title"]}</div>
                    <div className="col-sm" >{wi.rev}</div>
                </div>
            </div>
            ) 
    }

}
