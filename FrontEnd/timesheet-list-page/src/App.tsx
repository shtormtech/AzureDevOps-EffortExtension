import React from 'react';
import WorkItemsTable from './components/workItemTable';
import { TimesheetTable } from './components/timesheetTable';

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
