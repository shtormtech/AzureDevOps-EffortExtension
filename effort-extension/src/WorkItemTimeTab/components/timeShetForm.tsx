import * as React from "react";

import Button from "../common/button";
import TextArea from "../common/textArea";
import Input from "../common/input";

interface ITimeShetProp {
    userName: string;
    time: string;
    description: string;
}

interface ITimeShetState {
    newTimeShet:ITimeShetProp;
}

export class TimeShetForm extends React.Component<ITimeShetProp, ITimeShetState> {
    constructor(props: ITimeShetProp){
        super(props);
        
        this.state = {
            newTimeShet: this.props,

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
                    newTimeShet: {
                        ...prevState.newTimeShet,
                        [name]: value
                    }
                }
            ),
        () => console.log(this.state.newTimeShet)
        );
    };

    handleClearForm(e: any){
        e.preventDefault();
        this.setState(
            {
                newTimeShet: {
                    userName: "",
                    time: "",
                    description: ""
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
                    value ={this.state.newTimeShet.userName}
                    placeholder = {"Enter user name"}
                    handleChange = {this.handleInput}
                />{" "}
                <Input 
                    inputType = {"number"}
                    title = {"time"}
                    name = {"time"}
                    value ={this.state.newTimeShet.time}
                    placeholder = {"Enter time"}
                    handleChange = {this.handleInput}
                />{" "}
                <TextArea 
                    title = {"description"}                
                    name = {"description"}
                    rows = {10}
                    cols = {10}
                    value ={this.state.newTimeShet.description}
                    handleChange = {this.handleInput}
                    placeholder = {"Description"}
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
