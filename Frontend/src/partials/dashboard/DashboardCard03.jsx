import React from 'react';
import { FaClock } from 'react-icons/fa';

function DashboardCard03() {
  return (
    <div className="flex flex-col col-span-full sm:col-span-6 xl:col-span-3 bg-white dark:bg-gray-800 shadow-xs rounded-xl p-6">
      {/* Header */}
      <div className="flex items-center justify-between mb-3">
        <div className="w-10 h-10 bg-linear-to-br from-orange-400 to-orange-600 rounded-xl flex items-center justify-center">
          <FaClock className="text-white text-lg" />
        </div>
        <span className="text-sm font-medium text-red-600 bg-red-100 px-2 py-1 rounded-full">
          -3%
        </span>
      </div>

      {/* Main number */}
      <h3 className="text-2xl font-bold text-gray-800 dark:text-gray-100 mb-1">14</h3>
      <p className="text-sm text-gray-500">Unavailable</p>
    </div>
  );
}

export default DashboardCard03;
