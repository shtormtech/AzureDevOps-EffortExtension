import * as React from "react";

import {ITimesheet, ITimesheetProp, IUser, activityType} from "./common/interfaces"
import Button from "./common/button";
import TextArea from "./common/textArea";
import Input from "./common/input";
import Label from "./common/label"

import "./TimesheetForm.css"
import { DatePicker } from "VSS/Controls/Combos";

interface ITimesheetState {
    TimeShet:ITimesheet;
}

export class TimesheetForm extends React.Component<ITimesheetProp, ITimesheetState> {
    constructor(props: ITimesheetProp){
        super(props);
        
        this.state = {
            TimeShet: this.props.item,
        };

        this.handleInput = this.handleInput.bind(this);
        this.handleClearForm = this.handleClearForm.bind(this)
    }

    handleInput(e:any) {
        let value = e.target.value;
        let name = e.target.name;
        this.setState(
            prevState => (
                {
                    TimeShet: {
                        ...prevState.TimeShet,
                        [name]: value
                    }
                }
            ),
        () => console.log(this.state.TimeShet)
        );
    };

    handleClearForm(e: any){
        e.preventDefault();

        this.setState(
            {
                TimeShet: {
                    WorkItem: {
                        id: 0,
                        title: ""
                    },
                    user: {
                        id: 0,
                        email: "",
                        name: "",
                        imageUrl: "",
                        profileUrl: ""
                    },
                    date: new Date().getDate().toString(),
                    duration: 0,
                    comment: "",
                    activity: activityType.Development
                }
            }
        );
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
                            value = {this.state.TimeShet.user.name}
                        />
                        <Label
                            title = {"Тикет"}
                            name = {"ticket"}
                            value = {this.state.TimeShet.WorkItem.title}
                        />
                        <Input 
                            inputType = {"date"}
                            title = {"date"}
                            name = {"date"}
                            value ={this.state.TimeShet.date}
                            placeholder = {"Enter date"}
                            handleChange = {this.handleInput}
                        />{" "}
                        <Input 
                            inputType = {"number"}
                            title = {"duration"}
                            name = {"duration"}
                            value ={this.state.TimeShet.duration}
                            placeholder = {"Enter duration"}
                            handleChange = {this.handleInput}
                        />{" "}
                        <TextArea 
                            title = {"comment"}                
                            name = {"comment"}
                            rows = {3}
                            value ={this.state.TimeShet.comment}
                            handleChange = {this.handleInput}
                            placeholder = {"comment"}
                        />{" "} 
                        <Button 
                            action = {this.handleClearForm}
                            type = {"secondary"}
                            title = {"Clear"}
                            style = {buttonStyle}
                        />{" "}
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
