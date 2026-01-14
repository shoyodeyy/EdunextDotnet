import React from 'react';
import { FaCheckCircle } from 'react-icons/fa'; // <-- sửa tên icon đúng

function DashboardCard02() {
  return (
    <div className="flex flex-col col-span-full sm:col-span-6 xl:col-span-3 bg-white dark:bg-gray-800 shadow-xs rounded-xl p-6">
      {/* Header */}
      <div className="flex items-center justify-between mb-3">
        <div className="w-10 h-10 bg-linear-to-br from-green-400 to-green-600 rounded-xl flex items-center justify-center">
          <FaCheckCircle className="text-white text-lg" />
        </div>
        <span className="text-sm font-medium text-green-600 bg-green-100 px-2 py-1 rounded-full">
          +8%
        </span>
      </div>

      {/* Main number */}
      <h3 className="text-2xl font-bold text-gray-800 dark:text-gray-100 mb-1">142</h3>
      <p className="text-sm text-gray-500">Available</p>
    </div>
  );
}

export default DashboardCard02;
