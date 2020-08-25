import * as React from "react";
import "bootstrap/dist/css/bootstrap.css"
import { WorkItem } from "TFS/WorkItemTracking/Contracts";
//import { IWorkItem } from "./IWorkItem"

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
            <tr>
                <td className="ColWIType">{wi.fields["System.WorkItemType"]}</td>
                <td className="ColWItitle">(<a href={wi.url}>#{wi.id}</a>){wi.fields["System.Title"]}</td>
                <td className="ColWIeffort">{wi.rev}</td>
            </tr>
            ) 
    }

}
