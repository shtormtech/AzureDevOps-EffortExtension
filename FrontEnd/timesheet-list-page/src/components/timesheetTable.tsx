/* eslint-disable no-unused-vars */
/* eslint-disable react/display-name */
import {Table} from 'antd';
import React, {useState, useEffect} from 'react';
import 'antd/dist/antd.css';
import {ColumnType} from 'antd/lib/table';
import {TimesheetClient} from '../common/requests';
import {ITimesheetDto} from '../interfaces';

interface ITimesheet{
  key: number,
  date: Date,
  user: IUser,
  workItem: IWorkItem,
  duration: number,
  comment: string,
  activityType: IActivityType
}

interface IWorkItem{
  id: number,
  title: string,
  type: string
}

interface IUser{
  id: string,
  uniqueName: string,
  name: string,
  imageUrl: string,
  email: string
}

interface IActivityType{
  id: number,
  name: string,
  code: string,
  comment: string,
  color: string,
}

const columns: ColumnType<ITimesheet>[] = [
  {
    title: 'id',
    dataIndex: 'key',
    key: 'key',
  },
  {
    title: 'workItem',
    dataIndex: 'workItem',
    key: 'workItem',
    render: (record: IWorkItem) => <>{`(${record.id}) ${record.title}`}</>,
  },
  {
    title: 'date',
    dataIndex: 'date',
    key: 'date',
  },
  {
    title: 'user',
    dataIndex: 'user',
    key: 'user',
    render: (record: IUser) => <>{record.name}</>,
  },
  {
    title: 'duration',
    dataIndex: 'duration',
    key: 'duration',
  },
  {
    title: 'comment',
    dataIndex: 'comment',
    key: 'comment',
  },
  {
    title: 'activityType',
    dataIndex: 'activityType',
    key: 'activityType',
    render: (record: IActivityType) => <>{record.name}</>,
  },
  {
    title: 'activityType.name',
    dataIndex: 'activityType.name',
    key: 'activityType.name',
  },
];

/*
const data: ITimesheet[] = [
  {
    key: 1,
    date: '2014-12-24 23:12:00',
    user: {
      id: 'string',
      uniqueName: 'string',
      name: 'string',
      imageUrl: 'string',
      email: 'string',
    },
    workItem: {
      id: 1,
      title: 'string',
      type: 'string',
    },
    duration: 15,
    comment: 'comment',
    activityType: {
      id: 0,
      name: 'Activity name',
      code: 'code',
      comment: 'comment',
      color: 'red',
    },
  },
];
*/
export const TimesheetTable: React.FC = () => {
  const refreshHendler = () => {
    setLoading(true);
    TimesheetClient
        .get<ITimesheetDto[]>('/Timesheets')
        .then((resp) => {
          setLoading(false);
          const result: ITimesheet[] =
            resp.data.map((old: ITimesheetDto): ITimesheet => {
              const newWi: IWorkItem = {
                id: old.id,
                title: `WI Title`,
                type: 'WI Type',
              };

              const newAct: IActivityType = {
                id: old.activityType.id,
                code: old.activityType.code,
                name: old.activityType.name,
                comment: old.activityType.comment,
                color: old.activityType.color,
              };

              const newUser: IUser = {
                id: old.userUniqueName,
                uniqueName: old.userUniqueName,
                name: old.userUniqueName,
                email: old.userUniqueName,
                imageUrl: old.userUniqueName,
              };

              const newItem: ITimesheet = {
                key: old.id,
                activityType: newAct,
                workItem: newWi,
                comment: old.comment,
                date: old.date,
                duration: old.duration,
                user: newUser,
              };
              return newItem;
            });
          setTmesheets(result);
        })
        .catch((err) => {
          setLoading(false);
          console.error(err);
        });
  };

  useEffect(() => {
    refreshHendler();
  }, []);

  const [timesheets, setTmesheets] = useState<ITimesheet[]>([]);
  const [loading, setLoading] = useState<boolean>(false);

  return (
    <Table
      className="components-table-demo-nested"
      columns={columns}
      loading={loading}
      dataSource={timesheets}
    />
  );
};
