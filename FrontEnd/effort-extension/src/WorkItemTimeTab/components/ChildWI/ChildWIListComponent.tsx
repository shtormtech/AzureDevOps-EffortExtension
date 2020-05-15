import * as React from "react";
import {TestItems} from "../../../TestData/TestData";
import {ChildWIComponent} from "./ChildWIComponent";
import "bootstrap/dist/css/bootstrap.css"
import "./style.css"

export class ChildWIListComponent extends React.Component{
    public render(): JSX.Element {
        const items = TestItems.map(item => 
             <ChildWIComponent item={item} key={item.id}/>)
        return( 
            <table className="table" key="ChildItemTable">
                <tbody key="ChildItemTableBody">
                     {items}
                </tbody>
            </table>
        )
    }
}