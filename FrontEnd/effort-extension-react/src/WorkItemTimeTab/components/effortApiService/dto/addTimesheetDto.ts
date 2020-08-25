import {ITimesheet, ITimesheetProp, IUser, activityType} from "../../Timesheet/common/interfaces"

class addTimesheetDto{
    date: string;
    activityTypeId: activityType;
    userUniqueName: string;
    workItemId: number
    duration: number;
    comment: string;
    constructor(timesheet: ITimesheet ){
        this.activityTypeId = timesheet.activity;
        this.comment = timesheet.comment;
        this.date = timesheet.date;
        this.duration = Number(timesheet.duration);
        this.userUniqueName = timesheet.user.email;
        this.workItemId = timesheet.WorkItem.id;
    }

}
export default addTimesheetDto
