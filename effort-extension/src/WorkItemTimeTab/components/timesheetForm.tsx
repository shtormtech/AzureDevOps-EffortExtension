import * as React from "react";

import {ITimesheet, ITimesheetProp, activityType} from "../common/interfaces"
import Button from "../common/button";
import TextArea from "../common/textArea";
import Input from "../common/input";

interface ITimesheetState {
    TimeShet:ITimesheet;
}

export class TimesheetForm extends React.Component<ITimesheetProp, ITimesheetState> {
    constructor(props: ITimesheetProp){
        super(props);
        
        this.state = {
            TimeShet: this.props.item,

            //skillOptions: ["Programming", "Development", "Design", "Testing"]
        };

        this.handleInput = this.handleInput.bind(this);
        //this.handleTime = this.handleTime.bind(this);
        //this.handleDescription = this.handleDescription.bind(this);
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
            <form className="container-timeShet">
                <Input 
                    inputType = {"text"}
                    title = {"User name"}
                    name = {"userName"}
                    value ={this.state.TimeShet.user.name}
                    placeholder = {"Enter user name"}
                    handleChange = {this.handleInput}
                />{" "}
                <Input 
                    inputType = {"number"}
                    title = {"time"}
                    name = {"time"}
                    value ={this.state.TimeShet.duration}
                    placeholder = {"Enter time2w"}
                    handleChange = {this.handleInput}
                />{" "}
                <TextArea 
                    title = {"comment"}                
                    name = {"comment"}
                    rows = {10}
                    cols = {10}
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
            </form>
        );   
    }
}
const buttonStyle = {
    margin: "10px 10px 10px 10px"
};
