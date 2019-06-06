import * as React from "react";

const TextArea = (props: { 
            title: React.ReactNode; 
            name: string | undefined; 
            rows: number | undefined; 
            cols?: number | undefined; 
            value: string | number | string[] | undefined; 
            handleChange: (
                (event: React.ChangeEvent<HTMLTextAreaElement>) => void) | undefined; 
            placeholder: string | undefined; }
            ) => (
        <div className="TSFormRow">
            <div className="TSFormLabelCell">
                <label className="form-label">{props.title}</label>
            </div>    
            <div className="TSFormCell">
                <textarea
                    className="form-control"
                    name={props.name}
                    rows={props.rows}
                    cols={props.cols}
                    value={props.value}
                    onChange={props.handleChange}
                    placeholder={props.placeholder}
                    />
            </div>
        </div>
);

export default TextArea;