import {Table} from 'antd';
import React from 'react';
import 'antd/dist/antd.css';

interface IWorkItem{
  key: number
  type: string,
  icon: string,
  title: string,
  status: string,
  assignTo: string,
  children?: IWorkItem[]
}

const columns = [
  {
    title: 'id',
    dataIndex: 'key',
    key: 'key',
  },
  {
    title: 'type',
    dataIndex: 'type',
    key: 'type',
  },
  {
    title: 'icon',
    dataIndex: 'icon',
    key: 'icon',
  },
  {
    title: 'title',
    dataIndex: 'title',
    key: 'title',
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
      />
    </>
  );
}
