import * as React from "react";

const Label = (props: { 
    title: React.ReactNode; 
    name: string | undefined; 
    value: string | number | undefined; 
}) => {
    return (
        <div className="TSFormRow">
            <div className="TSFormLabelCell">
                <label htmlFor={props.name} className="form-label">
                    {props.title}
                </label> 
            </div>
            <div className="TSFormCell">
                {props.value}
            </div>
        </div>
    );
};

export default Label;