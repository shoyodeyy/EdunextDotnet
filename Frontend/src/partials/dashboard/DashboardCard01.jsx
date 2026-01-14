import React from 'react';
import { FaUtensils } from 'react-icons/fa';

function DashboardCard01() {
  return (
    <div className="flex flex-col col-span-full sm:col-span-6 xl:col-span-3 bg-white dark:bg-gray-800 shadow-xs rounded-xl p-6">
      {/* Top row: icon + growth */}
      <div className="flex items-center justify-between mb-4">
        <div className="w-12 h-12 bg-linear-to-br from-blue-400 to-blue-600 rounded-xl flex items-center justify-center">
          <FaUtensils className="text-white text-xl" />
        </div>
        <span className="text-sm font-medium text-green-600 bg-green-100 px-3 py-1 rounded-full">
          +12%
        </span>
      </div>

      {/* Main number */}
      <h3 className="text-3xl font-bold text-gray-800 dark:text-gray-100 mb-1">
        156
      </h3>
      <p className="text-sm text-gray-500">Total Dishes</p>
    </div>
  );
}

export default DashboardCard01;
