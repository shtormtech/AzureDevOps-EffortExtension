import * as React from "react";
import {TestItems} from "../../../TestData/TestData";
import {ChildWIComponent} from "./ChildWIComponent";

export class ChildWIListComponent extends React.Component{
    public render(): JSX.Element {
        const items = TestItems.map(item => 
            <li key={item.id}> <ChildWIComponent item={item}/> </li>)
        return( 
            <div>
                <ul>
                     {items}
                </ul>                
            </div>
        )
    }
}