import React from 'react';
import { FaChartPie } from 'react-icons/fa';
import { Pie } from 'react-chartjs-2';
import 'chart.js/auto'; // cần để Chart.js tự register

// Dữ liệu ví dụ cho Pie Chart (Category Distribution)
const chartData = {
  labels: ['Main Course', 'Desserts', 'Appetizers', 'Beverages', 'Salads'],
  datasets: [
    {
      label: 'Category Distribution',
      data: [35, 25, 20, 12, 8],
      backgroundColor: [
        '#3B82F6', // blue
        '#8B5CF6', // violet
        '#10B981', // green
        '#F59E0B', // amber
        '#EF4444', // red
      ],
      hoverOffset: 10,
    },
  ],
};

function DashboardCardCategory() {
  return (
    <div className="flex flex-col col-span-full sm:col-span-3 bg-white dark:bg-gray-800 shadow-xs rounded-xl p-6">
      {/* Header */}
      <div className="flex items-center justify-between mb-6">
        <div className="flex items-center space-x-3">
          <div className="w-10 h-10 bg-linear-to-br from-purple-400 to-purple-600 rounded-lg flex items-center justify-center text-white">
            <FaChartPie size={20} />
          </div>
          <h2 className="text-xl font-bold text-gray-800 dark:text-gray-100">Category Distribution</h2>
        </div>
      </div>

      {/* Pie Chart */}
       <div style={{ height: '300px' }}>
        <Pie data={chartData} height={200} />
      </div>
    </div>
  );
}

export default DashboardCardCategory;
