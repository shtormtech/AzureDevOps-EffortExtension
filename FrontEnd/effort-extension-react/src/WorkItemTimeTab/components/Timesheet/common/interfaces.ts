export interface ITimesheetProp{
    item: ITimesheet;
    isOpen:boolean;
    onClose:any;
} 

export interface ITimesheet{
    user: IUser;
    date: string;
    WorkItem: IWorkItem;
    duration: number;
    comment: string;
    activity: activityType;
}

export interface IWorkItem{
    id: number;
    title: string;
}

export interface IUser{
    id: number;
    email: string;
    name: string;
    imageUrl: string;
    profileUrl: string;
} 

export enum activityType{
    Programming, 
    Development, 
    Design,
    Testing
};