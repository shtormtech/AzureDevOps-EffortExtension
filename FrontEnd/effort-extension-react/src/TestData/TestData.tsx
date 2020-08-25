import { WorkItem } from "TFS/WorkItemTracking/Contracts";
//import {IWorkItem} from "../WorkItemTimeTab/components/ChildWI/IWorkItem";
export const TestItems: WorkItem[] = [
    {
        "id": 18,
        "rev": 1,
        "_links":{},
        "fields": {
            "System.AreaPath": "effort-extension",
            "System.TeamProject": "effort-extension",
            "System.IterationPath": "effort-extension",
            "System.WorkItemType": "Feature",
            "System.State": "New",
            "System.Reason": "New",
            "System.CreatedDate": "2019-01-31T20:17:35.88Z",
            "System.CreatedBy": {
                "displayName": "iloer",
                "url": "https://app.vssps.visualstudio.com/A822c1d95-7bc6-4ed6-bbfa-99ea4f4a9daa/_apis/Identities/aafbb425-c54f-45f9-a637-08a42242fff6",
                "_links": {
                    "avatar": {
                        "href": "https://dev.azure.com/iloer/_apis/GraphProfile/MemberAvatars/msa.NDZmN2ZmMzEtYmIwOC03ZjdlLTlhNzktODFhZGM4NzU5NjRj"
                    }
                },
                "id": "aafbb425-c54f-45f9-a637-08a42242fff6",
                "uniqueName": "iloer@mail.ru",
                "imageUrl": "https://dev.azure.com/iloer/_api/_common/identityImage?id=aafbb425-c54f-45f9-a637-08a42242fff6",
                "descriptor": "msa.NDZmN2ZmMzEtYmIwOC03ZjdlLTlhNzktODFhZGM4NzU5NjRj"
            },
            "System.ChangedDate": "2019-01-31T20:17:35.88Z",
            "System.ChangedBy": {
                "displayName": "iloer",
                "url": "https://app.vssps.visualstudio.com/A822c1d95-7bc6-4ed6-bbfa-99ea4f4a9daa/_apis/Identities/aafbb425-c54f-45f9-a637-08a42242fff6",
                "_links": {
                    "avatar": {
                        "href": "https://dev.azure.com/iloer/_apis/GraphProfile/MemberAvatars/msa.NDZmN2ZmMzEtYmIwOC03ZjdlLTlhNzktODFhZGM4NzU5NjRj"
                    }
                },
                "id": "aafbb425-c54f-45f9-a637-08a42242fff6",
                "uniqueName": "iloer@mail.ru",
                "imageUrl": "https://dev.azure.com/iloer/_api/_common/identityImage?id=aafbb425-c54f-45f9-a637-08a42242fff6",
                "descriptor": "msa.NDZmN2ZmMzEtYmIwOC03ZjdlLTlhNzktODFhZGM4NzU5NjRj"
            },
            "System.CommentCount": 0,
            "System.Title": "Features API for test",
            "Microsoft.VSTS.Common.StateChangeDate": "2019-01-31T20:17:35.88Z",
            "Microsoft.VSTS.Common.Priority": 2,
            "Microsoft.VSTS.Common.ValueArea": "Business"
        },
        "relations": [
            {
                "rel": "System.LinkTypes.Hierarchy-Forward",
                "url": "https://dev.azure.com/iloer/4e644721-971c-4d09-b820-56ea5ce4b8df/_apis/wit/workItems/11",
                "attributes": {
                    "isLocked": false
                }
            },
            {
                "rel": "System.LinkTypes.Hierarchy-Forward",
                "url": "https://dev.azure.com/iloer/4e644721-971c-4d09-b820-56ea5ce4b8df/_apis/wit/workItems/12",
                "attributes": {
                    "isLocked": false
                }
            },
            {
                "rel": "System.LinkTypes.Hierarchy-Reverse",
                "url": "https://dev.azure.com/iloer/4e644721-971c-4d09-b820-56ea5ce4b8df/_apis/wit/workItems/10",
                "attributes": {
                    "isLocked": false
                }
            }
        ],
        "url": "ddd"
    },
    {
        "id": 11,
        "rev": 1,
        "_links":{},
        "fields": {
            "System.AreaPath": "effort-extension",
            "System.TeamProject": "effort-extension",
            "System.IterationPath": "effort-extension",
            "System.WorkItemType": "User Story",
            "System.State": "New",
            "System.Reason": "New",
            "System.CreatedDate": "2019-01-20T15:59:20.15Z",
            "System.CreatedBy": {
                "displayName": "iloer",
                "url": "https://app.vssps.visualstudio.com/A822c1d95-7bc6-4ed6-bbfa-99ea4f4a9daa/_apis/Identities/aafbb425-c54f-45f9-a637-08a42242fff6",
                "_links": {
                    "avatar": {
                        "href": "https://dev.azure.com/iloer/_apis/GraphProfile/MemberAvatars/msa.NDZmN2ZmMzEtYmIwOC03ZjdlLTlhNzktODFhZGM4NzU5NjRj"
                    }
                },
                "id": "aafbb425-c54f-45f9-a637-08a42242fff6",
                "uniqueName": "iloer@mail.ru",
                "imageUrl": "https://dev.azure.com/iloer/_api/_common/identityImage?id=aafbb425-c54f-45f9-a637-08a42242fff6",
                "descriptor": "msa.NDZmN2ZmMzEtYmIwOC03ZjdlLTlhNzktODFhZGM4NzU5NjRj"
            },
            "System.ChangedDate": "2019-01-20T15:59:20.15Z",
            "System.ChangedBy": {
                "displayName": "iloer",
                "url": "https://app.vssps.visualstudio.com/A822c1d95-7bc6-4ed6-bbfa-99ea4f4a9daa/_apis/Identities/aafbb425-c54f-45f9-a637-08a42242fff6",
                "_links": {
                    "avatar": {
                        "href": "https://dev.azure.com/iloer/_apis/GraphProfile/MemberAvatars/msa.NDZmN2ZmMzEtYmIwOC03ZjdlLTlhNzktODFhZGM4NzU5NjRj"
                    }
                },
                "id": "aafbb425-c54f-45f9-a637-08a42242fff6",
                "uniqueName": "iloer@mail.ru",
                "imageUrl": "https://dev.azure.com/iloer/_api/_common/identityImage?id=aafbb425-c54f-45f9-a637-08a42242fff6",
                "descriptor": "msa.NDZmN2ZmMzEtYmIwOC03ZjdlLTlhNzktODFhZGM4NzU5NjRj"
            },
            "System.CommentCount": 0,
            "System.Title": "API For User",
            "System.BoardColumn": "New",
            "System.BoardColumnDone": false,
            "Microsoft.VSTS.Common.StateChangeDate": "2019-01-20T15:59:20.15Z",
            "Microsoft.VSTS.Common.Priority": 2,
            "Microsoft.VSTS.Common.ValueArea": "Business",
            "WEF_6880980AF96A4DCEAA7A5B01C24C9D92_Kanban.Column": "New",
            "WEF_6880980AF96A4DCEAA7A5B01C24C9D92_Kanban.Column.Done": false
        },
        "relations": [
            {
                "rel": "System.LinkTypes.Hierarchy-Reverse",
                "url": "https://dev.azure.com/iloer/4e644721-971c-4d09-b820-56ea5ce4b8df/_apis/wit/workItems/18",
                "attributes": {
                    "isLocked": false
                }
            }
        ],
        "url": "https://dev.azure.com/iloer/4e644721-971c-4d09-b820-56ea5ce4b8df/_apis/wit/workItems/11"
    },
    {
        "id": 12,
        "rev": 1,
        "_links":{},
        "fields": {
            "System.AreaPath": "effort-extension",
            "System.TeamProject": "effort-extension",
            "System.IterationPath": "effort-extension",
            "System.WorkItemType": "User Story",
            "System.State": "New",
            "System.Reason": "New",
            "System.CreatedDate": "2019-01-20T15:59:42.12Z",
            "System.CreatedBy": {
                "displayName": "iloer",
                "url": "https://app.vssps.visualstudio.com/A822c1d95-7bc6-4ed6-bbfa-99ea4f4a9daa/_apis/Identities/aafbb425-c54f-45f9-a637-08a42242fff6",
                "_links": {
                    "avatar": {
                        "href": "https://dev.azure.com/iloer/_apis/GraphProfile/MemberAvatars/msa.NDZmN2ZmMzEtYmIwOC03ZjdlLTlhNzktODFhZGM4NzU5NjRj"
                    }
                },
                "id": "aafbb425-c54f-45f9-a637-08a42242fff6",
                "uniqueName": "iloer@mail.ru",
                "imageUrl": "https://dev.azure.com/iloer/_api/_common/identityImage?id=aafbb425-c54f-45f9-a637-08a42242fff6",
                "descriptor": "msa.NDZmN2ZmMzEtYmIwOC03ZjdlLTlhNzktODFhZGM4NzU5NjRj"
            },
            "System.ChangedDate": "2019-01-20T15:59:42.12Z",
            "System.ChangedBy": {
                "displayName": "iloer",
                "url": "https://app.vssps.visualstudio.com/A822c1d95-7bc6-4ed6-bbfa-99ea4f4a9daa/_apis/Identities/aafbb425-c54f-45f9-a637-08a42242fff6",
                "_links": {
                    "avatar": {
                        "href": "https://dev.azure.com/iloer/_apis/GraphProfile/MemberAvatars/msa.NDZmN2ZmMzEtYmIwOC03ZjdlLTlhNzktODFhZGM4NzU5NjRj"
                    }
                },
                "id": "aafbb425-c54f-45f9-a637-08a42242fff6",
                "uniqueName": "iloer@mail.ru",
                "imageUrl": "https://dev.azure.com/iloer/_api/_common/identityImage?id=aafbb425-c54f-45f9-a637-08a42242fff6",
                "descriptor": "msa.NDZmN2ZmMzEtYmIwOC03ZjdlLTlhNzktODFhZGM4NzU5NjRj"
            },
            "System.CommentCount": 0,
            "System.Title": "API For WorkItems",
            "System.BoardColumn": "New",
            "System.BoardColumnDone": false,
            "Microsoft.VSTS.Common.StateChangeDate": "2019-01-20T15:59:42.12Z",
            "Microsoft.VSTS.Common.Priority": 2,
            "Microsoft.VSTS.Common.ValueArea": "Business",
            "WEF_6880980AF96A4DCEAA7A5B01C24C9D92_Kanban.Column": "New",
            "WEF_6880980AF96A4DCEAA7A5B01C24C9D92_Kanban.Column.Done": false
        },
        "relations": [
            {
                "rel": "System.LinkTypes.Hierarchy-Reverse",
                "url": "https://dev.azure.com/iloer/4e644721-971c-4d09-b820-56ea5ce4b8df/_apis/wit/workItems/18",
                "attributes": {
                    "isLocked": false
                }
            }
        ],
        "url": "https://dev.azure.com/iloer/4e644721-971c-4d09-b820-56ea5ce4b8df/_apis/wit/workItems/12"
    }
];
//};
//}