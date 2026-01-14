import React, { useState } from 'react';

import Sidebar from '../partials/Sidebar';
import Header from '../partials/Header';

import DashboardCard01 from '../partials/dashboard/DashboardCard01';
import DashboardCard02 from '../partials/dashboard/DashboardCard02';
import DashboardCard03 from '../partials/dashboard/DashboardCard03';
import DashboardCard04 from '../partials/dashboard/DashboardCard04';
import DashboardCard05 from '../partials/dashboard/DashboardCard05';
import DishForm from '../partials/dashboard/DishForm';
import ManageDish from '../partials/dashboard/ManageDish';
import UploadDishImage from '../partials/dashboard/UploadDishImage';
import RecentOrdersCard from '../partials/dashboard/RecentOrdersCard';
import DashboardCardTopDishes from '../partials/dashboard/DashboardCardTopDishes';
import DashboardCard03_2 from '../partials/dashboard/DashboardCard03_2';

function Dashboard() {
  const [sidebarOpen, setSidebarOpen] = useState(false);

  return (
    <div className="flex h-screen overflow-hidden">
      {/* Sidebar */}
      <Sidebar sidebarOpen={sidebarOpen} setSidebarOpen={setSidebarOpen} />

      {/* Content area */}
      <div className="relative flex flex-col flex-1 overflow-y-auto overflow-x-hidden">
        {/* Site header */}
        <Header sidebarOpen={sidebarOpen} setSidebarOpen={setSidebarOpen} />

        <main className="grow">
          <div className="px-4 sm:px-6 lg:px-8 py-8 w-full max-w-9xl mx-auto">

            {/* Dashboard header */}
            <div className="sm:flex sm:justify-between sm:items-center mb-8">
              <div className="mb-4 sm:mb-0">
                <h1 className="text-2xl md:text-3xl text-gray-800 dark:text-gray-100 font-bold">Dashboard</h1>
              </div>

              <div className="grid grid-flow-col sm:auto-cols-max justify-start sm:justify-end gap-2">
              </div>
            </div>

            {/* Dashboard Cards */}
            <div className="grid grid-cols-12 gap-6 mb-6">
              <DashboardCard01 />
              <DashboardCard02 />
              <DashboardCard03 />
              <DashboardCard03_2 />
              <DashboardCard04 />
              <DashboardCard05 />
              <DashboardCardTopDishes/>
            </div>

            {/* Management Section */}
            <div className="mb-8">
              <h2 className="text-2xl md:text-3xl text-gray-800 dark:text-gray-100 font-bold mb-8">Management</h2>
              <div className="grid grid-cols-12 gap-6">
                <DishForm />
                <UploadDishImage />
                <ManageDish />
                <RecentOrdersCard />
              </div>
            </div>

            

          </div>
        </main>
      </div>
    </div>
  );
}

export default Dashboard;
