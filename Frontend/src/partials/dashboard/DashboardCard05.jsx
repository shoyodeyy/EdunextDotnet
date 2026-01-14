import React, { useState } from 'react';
import { FaChartLine } from 'react-icons/fa';
import { Line } from 'react-chartjs-2';
import 'chart.js/auto';

function DashboardCard05() {
  const [period, setPeriod] = useState('Last 7 Days');

  // Dummy data for demo
  const labels = ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'];
  const data = {
    labels: labels,
    datasets: [
      {
        label: 'Sales',
        data: [1200, 1900, 3000, 5000, 2000, 3000, 4000],
        fill: true,
        backgroundColor: 'rgba(59,130,246,0.1)',
        borderColor: 'rgba(59,130,246,1)',
        tension: 0.3,
        pointRadius: 3,
        pointBackgroundColor: 'rgba(59,130,246,1)',
      },
    ],
  };

  return (
    <div className="neumorphic-card p-6 flex flex-col col-span-full sm:col-span-9 bg-white dark:bg-gray-800 shadow-xs rounded-xl">
      {/* Header */}
      <div className="flex items-center justify-between mb-6">
        <div className="flex items-center space-x-3">
          <div className="w-10 h-10 bg-linear-to-br from-blue-400 to-blue-600 rounded-lg flex items-center justify-center">
            <FaChartLine className="text-white text-lg" />
          </div>
          <h2 className="text-xl font-bold text-gray-800 dark:text-gray-100">Sales Overview</h2>
        </div>
        <select
          value={period}
          onChange={(e) => setPeriod(e.target.value)}
          className="neumorphic-input px-3 py-2 rounded-lg text-xs text-gray-700"
        >
          <option>Last 7 Days</option>
          <option>Last 30 Days</option>
          <option>Last 3 Months</option>
          <option>Last Year</option>
        </select>
      </div>

      {/* Chart */}
      <div style={{ height: '300px' }}>
        <Line data={data} options={{ maintainAspectRatio: false }} />
      </div>
    </div>
  );
}

export default DashboardCard05;
