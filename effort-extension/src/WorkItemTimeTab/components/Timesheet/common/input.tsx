import * as React from "react";

const Input = (props: { 
    title: React.ReactNode; 
    name: string | undefined; 
    inputType: string | undefined; 
    value: string | number | string[] | undefined; 
    handleChange: (
        (event: React.ChangeEvent<HTMLInputElement>) => void) | undefined; 
    placeholder: string | undefined; } 
    ) => {
    return (
        <div className="TSFormRow">
            <div className="TSFormLabelCell">
                <label htmlFor={props.name} className="form-label">
                    {props.title}
                </label> 
            </div>
            <div className="TSFormCell">
                <input
                    className="form-control"
                    id={props.name}
                    name={props.name}
                    type={props.inputType}
                    value={props.value}
                    onChange={props.handleChange}
                    placeholder={props.placeholder}
                />
            </div>
        </div>
    );
};

export default Input;