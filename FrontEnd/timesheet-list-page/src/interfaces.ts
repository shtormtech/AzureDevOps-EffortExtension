export interface IActivityTypeDto {
    id: number;
    name: string;
    code: string;
    comment: string;
    isDeleted: boolean;
    color: string;
}

export interface ITimesheetDto {
    id: number;
    date: Date;
    userUniqueName: string;
    workItemId: number;
    duration: number;
    comment: string;
    isDeleted: boolean;
    activityTypeId: number;
    activityType: IActivityTypeDto;
}
