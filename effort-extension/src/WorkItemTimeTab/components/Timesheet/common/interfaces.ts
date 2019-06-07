export interface ITimesheetProp{
    item: ITimesheet;
    isOpen:boolean;
    onClose:any;
} 

export interface ITimesheet{
    user: IUser;
    date: Date | null;
    WIdi: number | null;
    duration: number;
    comment: string;
    activity: activityType | null;
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