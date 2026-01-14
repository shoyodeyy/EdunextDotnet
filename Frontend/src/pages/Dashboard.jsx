import React, { useState } from "react";
import Sidebar from "../partials/Sidebar";
import Header from "../partials/Header";

import DashboardCard01 from "../partials/dashboard/DashboardCard01";
import DashboardCard02 from "../partials/dashboard/DashboardCard02";
import DashboardCard03 from "../partials/dashboard/DashboardCard03";
import DashboardCard03_2 from "../partials/dashboard/DashboardCard03_2";
import DashboardCard04 from "../partials/dashboard/DashboardCard04";
import DashboardCard05 from "../partials/dashboard/DashboardCard05";
import DashboardCardTopDishes from "../partials/dashboard/DashboardCardTopDishes";

import DishForm from "../partials/dashboard/DishForm";
import ManageDish from "../partials/dashboard/ManageDish";
import UploadDishImage from "../partials/dashboard/UploadDishImage";
import RecentOrdersCard from "../partials/dashboard/RecentOrdersCard";

function Dashboard() {
  const [sidebarOpen, setSidebarOpen] = useState(false);

  return (
    <div className="flex h-screen overflow-hidden">
      <Sidebar sidebarOpen={sidebarOpen} setSidebarOpen={setSidebarOpen} />

      {/* Content */}
      <div className="relative flex flex-col flex-1 overflow-y-auto overflow-x-hidden">
        <Header sidebarOpen={sidebarOpen} setSidebarOpen={setSidebarOpen} />

        <main className="flex-1 overflow-y-auto">
          <div className="px-4 sm:px-6 lg:px-8 py-8 max-w-7xl mx-auto">
            <h1 className="text-3xl font-bold text-gray-800 dark:text-gray-100 mb-8">
              Dashboard
            </h1>

            {/* Cards */}
            <div className="grid grid-cols-12 gap-6 mb-10">
              <DashboardCard01 />
              <DashboardCard02 />
              <DashboardCard03 />
              <DashboardCard03_2 />
              <DashboardCard04 />
              <DashboardCard05 />
              <DashboardCardTopDishes />
            </div>

            {/* Management */}
            <h2 className="text-2xl font-bold text-gray-800 dark:text-gray-100 mb-6">
              Management
            </h2>

            <div className="grid grid-cols-12 gap-6">
              <DishForm />
              <UploadDishImage />
              <ManageDish />
              <RecentOrdersCard />
            </div>
          </div>
        </main>
      </div>
    </div>
  );
}

export default Dashboard;
