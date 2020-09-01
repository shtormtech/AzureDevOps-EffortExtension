import React from 'react';
import WorkItemsTable from './workItemTable';
import { TimesheetTable } from './timesheetTable';

const App: React.FC = () => {
  return (
    <div>
      <h1> Hello </h1>
      <div id='tt'></div>
      <WorkItemsTable/>
      <TimesheetTable/>
    </div>
  );
};

export default App;
