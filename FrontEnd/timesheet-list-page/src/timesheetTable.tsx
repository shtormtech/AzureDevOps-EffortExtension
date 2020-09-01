import {Table} from 'antd';
import React from 'react';
import 'antd/dist/antd.css';
import { ColumnType } from 'antd/lib/table';

interface ITimeSheet{
  key: number,
  date: string,
  userUniqueName: string,
  workItemId: number,
  duration: number,
  comment: string,
  activityType: IActivityType
}

interface IActivityType{
  id: 0,
  name: string,
  code: string,
  comment: string,
  color: string,
}

const columns: ColumnType<ITimeSheet>[] = [
  {
    title: 'id',
    dataIndex: 'key',
    key: 'key',
  },
  {
    title: 'date',
    dataIndex: 'date',
    key: 'date',
  },
  {
    title: 'userUniqueName',
    dataIndex: 'userUniqueName',
    key: 'userUniqueName',
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

const data: ITimeSheet[] = [
  {
    key: 1,
    date: '2014-12-24 23:12:00',
    userUniqueName: 'userUniqueName',
    workItemId: 3,
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

export const TimesheetTable: React.FC = () => {
  return (
    <Table
      className="components-table-demo-nested"
      columns={columns}
      dataSource={data}
    />
  );
};
