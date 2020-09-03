import {Table} from 'antd';
import React from 'react';
import 'antd/dist/antd.css';
import './table.scss';
import { ColumnType } from 'antd/lib/table/interface';

interface IWorkItem{
  key: number
  type: string,
  icon: string,
  title: string,
  status: string,
  assignTo: string,
  children?: IWorkItem[]
}

const columns: ColumnType<IWorkItem>[] = [
  {
    title: 'title',
    dataIndex: 'title',
    key: 'title',
    width: '15%',
    render: (_value: string, record: IWorkItem) => 
          <div>
            <svg style={{height:'15px'}} xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 448"><path d="M320 352c-22.846 0-60.713 5.861-80 16.588V55.635C257.752 40.563 296.084 32 320 32h64v320h-64zm-192 32H32V64H0v352h208s-16-32-80-32zM64 32v320h64c22.848 0 60.707 5.865 80 16.594V55.635C190.244 40.561 151.902 32 128 32H64zm352 32v320h-96c-64 0-80 32-80 32h208V64h-32z" /></svg> 
            {`(${record.key}) ${record.title}`}
          </div>,
  },
  {
    title: 'type',
    dataIndex: 'type',
    key: 'type',
  },
  {
    title: 'status',
    dataIndex: 'status',
    key: 'status',
  },
  {
    title: 'assignTo',
    dataIndex: 'assignTo',
    key: 'assignTo',
  },
];

const data: IWorkItem[] = [
  {
    key: 1,
    type: 'Feature',
    icon: 'iconUrl',
    title: 'FeatureTitle1',
    status: 'Active',
    assignTo: 'User 1',
    children: [
      {
        key: 2,
        type: 'UserStory',
        icon: 'iconUrl',
        title: 'UserStoryTitle',
        status: 'Active',
        assignTo: 'User 1',
      },
      {
        key: 3,
        type: 'UserStory',
        icon: 'iconUrl',
        title: 'UserStoryTitle3',
        status: 'Active',
        assignTo: 'User 1',
        children: [
          {
            key: 4,
            type: 'Task',
            icon: 'iconUrl',
            title: 'TaskTitle4',
            status: 'Active',
            assignTo: 'User 1',
          },
          {
            key: 5,
            type: 'Task',
            icon: 'iconUrl',
            title: 'TaskTitle5',
            status: 'Active',
            assignTo: 'User 1',
          },
        ],
      },
      {
        key: 6,
        type: 'UserStory',
        icon: 'iconUrl',
        title: 'UserStoryTitle6',
        status: 'Active',
        assignTo: 'User 1',
        children: [
          {
            key: 7,
            type: 'Task',
            icon: 'iconUrl',
            title: 'TaskTitle7',
            status: 'Active',
            assignTo: 'User 1',
          },
          {
            key: 8,
            type: 'Task',
            icon: 'iconUrl',
            title: 'TaskTitle8',
            status: 'Active',
            assignTo: 'User 1',
          },
        ],
      },
    ],
  },
  {
    key: 9,
    type: 'Feature',
    icon: 'iconUrl',
    title: 'FeatureTitle9',
    status: 'Active',
    assignTo: 'User 1',
    children: [
      {
        key: 10,
        type: 'UserStory',
        icon: 'iconUrl',
        title: 'UserStoryTitle',
        status: 'Active',
        assignTo: 'User 1',
      },
    ],
  },
];

export default function WorkItemsTable() {
  return (
    <>
      <Table
        columns={columns}
        pagination={false}
        dataSource={data}
        className='myTable'
      />
    </>
  );
}
