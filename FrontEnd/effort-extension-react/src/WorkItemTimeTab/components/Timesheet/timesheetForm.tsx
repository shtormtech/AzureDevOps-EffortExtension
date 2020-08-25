import * as React from "react";

import {ITimesheet, ITimesheetProp, IUser, activityType} from "./common/interfaces"
import Button from "./common/button";
import TextArea from "./common/textArea";
import Input from "./common/input";
import Label from "./common/label";
import addTimesheetDto from "../effortApiService/dto/addTimesheetDto";

import "./TimesheetForm.css" 
import { DatePicker } from "VSS/Controls/Combos";

interface ITimesheetState {
    TimeSheet:ITimesheet;
}

export class TimesheetForm extends React.Component<ITimesheetProp, ITimesheetState> {
    constructor(props: ITimesheetProp){
        super(props);
        
        this.state = {
            TimeSheet: this.props.item
        };

        this.handleInput = this.handleInput.bind(this);
        this.handleClearForm = this.handleClearForm.bind(this)
        this.handleAddTimesheet = this.handleAddTimesheet.bind(this)
    }
    
    handleInput(e:any) {
        let value = e.target.value;
        let name = e.target.name;
        this.setState(
            prevState => (
                {
                    TimeSheet: {
                        ...prevState.TimeSheet,
                        [name]: value
                    }
                }
            ),
        () => console.log(this.state.TimeSheet)
        );
    };

    handleClearForm(e: any){
        e.preventDefault();

        this.setState(
            prevState => (
                {
                    TimeSheet: {
                        ...prevState.TimeSheet,
                        date: "",
                        duration: 0,
                        comment: ""
                    }
                }
            ),
        () => console.log(this.state.TimeSheet)
        );
    }

    async handleAddTimesheet(e:any){
        e.preventDefault();
        let dto = new addTimesheetDto(this.state.TimeSheet);
        console.log("JSON: " + JSON.stringify(dto))
        const response = await fetch("http://iloer.francecentral.cloudapp.azure.com:31051/api/Timesheets", {
            method: 'POST',
            body: JSON.stringify(dto),
            headers: {'Content-Type': 'application/json; charset=UTF-8'} });
          
          if (!response.ok) { /* Handle */ }
          
          // If you care about a response:
          if (response.body !== null) {
            // body is ReadableStream<Uint8Array>
            // parse as needed, e.g. reading directly, or
            //const asString = new TextDecoder("utf-8").decode(response.body);
            // and further:
            //const asJSON = JSON.parse(asString);  // implicitly 'any', make sure to verify type on runtime.
            console.log("responce: " + response.json)
            }
    }

    close(e:any) {
        e.preventDefault();
    
        if (this.props.onClose) {
          this.props.onClose();
        }
      }

    render() {
        if (this.props.isOpen === false) return null;
        return(
            <form className="container-timesheet">
                <div className="TSFormTable">{this.props.children}
                    <div className="TSFormBody">
                        <Label
                            title = {"Пользователь"}
                            name = {"user"}
                            value = {this.state.TimeSheet.user.name}
                        />
                        <Label
                            title = {"Тикет"}
                            name = {"ticket"}
                            value = {this.state.TimeSheet.WorkItem.title}
                        />
                        <Input 
                            inputType = {"date"}
                            title = {"date"}
                            name = {"date"}
                            value ={this.state.TimeSheet.date}
                            placeholder = {"Enter date"}
                            handleChange = {this.handleInput}
                        />{" "}
                        <Input 
                            inputType = {"number"}
                            title = {"duration"}
                            name = {"duration"}
                            value ={this.state.TimeSheet.duration}
                            placeholder = {"Enter duration"}
                            handleChange = {this.handleInput}
                        />{" "}
                        <TextArea 
                            title = {"comment"}                
                            name = {"comment"}
                            rows = {3}
                            value ={this.state.TimeSheet.comment}
                            handleChange = {this.handleInput}
                            placeholder = {"comment"}
                        />{" "} 
                        <div className="TSFormRow" >
                            <div className="TSFormCell">
                                <Button 
                                    action = {this.handleClearForm}
                                    type = {"secondary"}
                                    title = {"Clear"}
                                    style = {buttonStyle}
                                />{" "}
                            </div>
                            <div className="TSFormCell" >
                                <Button 
                                    action = {this.handleAddTimesheet}
                                    type = {"secondary"}
                                    title = {"Add"}
                                    style = {buttonStyle}
                                />{" "}
                            </div>
                        </div>
                    </div>
                </div>
                <div className="bg" onClick={e => this.close(e)} />
            </form>
        );   
    }
}
const buttonStyle = {
    margin: "10px 10px 10px 10px"
};
