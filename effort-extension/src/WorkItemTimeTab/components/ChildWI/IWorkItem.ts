
    export interface Avatar {
        href: string;
    };

    export interface Links {
        avatar: Avatar;
    };

    export interface SystemCreatedBy {
        displayName: string;
        url: string;
        _links: Links;
        id: string;
        uniqueName: string;
        imageUrl: string;
        descriptor: string;
    };

    export interface SystemChangedBy {
        displayName: string;
        url: string;
        _links: Links;
        id: string;
        uniqueName: string;
        imageUrl: string;
        descriptor: string;
    };

    export interface Fields {
        "System.AreaPath": string;
        "System.TeamProject": string;
        "System.IterationPath": string;
        "System.WorkItemType": string;
        "System.State": string;
        "System.Reason": string;
        "System.CreatedDate": Date;
        "System.CreatedBy": SystemCreatedBy;
        "System.ChangedDate": Date;
        "System.ChangedBy": SystemChangedBy;
        "System.CommentCount": number;
        "System.Title": string;
        "Microsoft.VSTS.Common.StateChangeDate": Date;
        "Microsoft.VSTS.Common.Priority": number;
        "Microsoft.VSTS.Common.ValueArea": string;
    };

    export interface Attributes {
        isLocked: boolean;
    };

    export interface Relation {
        rel: string;
        url: string;
        attributes: Attributes;
    };

    export interface IWorkItem {
        id: number;
        rev: number;
        fields: Fields;
        relations: Relation[];
        url: string;
    };
