import * as React from "react";

import {ITimesheet, ITimesheetProp, IUser, activityType} from "./common/interfaces"
import Button from "./common/button";
import TextArea from "./common/textArea";
import Input from "./common/input";

import "./TimesheetForm.css"

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
        this.handleInputUser = this.handleInputUser.bind(this);
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

    handleInputUser(e:any) {
        let value = e.target.value;
        this.setState(
            prevState => (
                {
                    TimeShet: {
                        ...prevState.TimeShet,
                        user: {
                            ...prevState.TimeShet.user,
                            name: value
                        }
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
                    user: {
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
                }
            }
        );
    }

    render() {
        return(
            <form className="container-timesheet">
                <div className="TSFormTable">
                    <div className="TSFormBody">
                    <Input 
                        inputType = {"text"}
                        title = {"User name"}
                        name = {"UserName"}
                        value ={this.state.TimeShet.user.name}
                        placeholder = {"Enter user name"}
                        handleChange = {this.handleInputUser}
                    />
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
            </form>
        );   
    }
}
const buttonStyle = {
    margin: "10px 10px 10px 10px"
};
