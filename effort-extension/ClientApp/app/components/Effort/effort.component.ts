import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'effort',
    templateUrl: './effort.component.html',
    styleUrls: ['./effort.component.css']
})
export class EffortDataComponent {
    public efforts: effort[] | undefined;
    public teams: teamuser[] | undefined;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {

        http.get(baseUrl + 'api/TfsWorkItems/GetTfsWorkItemEfforts?WitId=20').subscribe(result => {
            this.efforts = result.json() as effort[];
        }, error => console.error(error));

        
        http.get(baseUrl + 'api/TfsWorkItems/GetTfsWorkItemUserEffort?witid=20').subscribe(result => {
            this.teams = result.json() as teamuser[];
        }, error => console.error(error));
        
    }
}

interface effort {
//{"id":73,"workItemId":20,"userId":"UserEmail","minute":411,"comment":"Comment"}
    Id: number;
    workItemId: string;
    userId: number;
    UserEmail: string;
    minute: string;
    comment: string;
    worktype: number
}

interface teamuser {
 //{"userid":21,"username":"UseName","userlogin":"UserEmail","effortminute":404}
    userid: number;
    username: string;
    userlogin: string;
    effortminute: number
}
