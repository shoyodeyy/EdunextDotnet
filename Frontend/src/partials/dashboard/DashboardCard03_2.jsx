import React from 'react';
import { FaDollarSign } from 'react-icons/fa';

function DashboardCard03_2() {
  return (
    <div className="flex flex-col col-span-full sm:col-span-6 xl:col-span-3 bg-white dark:bg-gray-800 shadow-xs rounded-xl p-6">
      {/* Header */}
      <div className="flex items-center justify-between mb-3">
        <div className="w-10 h-10 bg-linear-to-br from-purple-400 to-purple-600 rounded-xl flex items-center justify-center">
          <FaDollarSign className="text-white text-lg" />
        </div>
        <span className="text-sm font-medium text-green-600 bg-green-100 px-2 py-1 rounded-full">
          +24%
        </span>
      </div>

      {/* Main number */}
      <h3 className="text-2xl font-bold text-gray-800 dark:text-gray-100 mb-1">$18.5k</h3>
      <p className="text-sm text-gray-500">Avg. Revenue</p>
    </div>
  );
}

export default DashboardCard03_2;
