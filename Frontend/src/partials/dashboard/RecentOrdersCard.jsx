import React from "react";
import { FaReceipt, FaUtensils, FaCheck, FaClock, FaArrowRight } from "react-icons/fa";

const orders = [
  { id: 12456, table: 8, items: 2, total: 43.48, status: "Preparing", color: "yellow", icon: FaUtensils, iconBg: "bg-blue-100", iconColor: "text-blue-600" },
  { id: 12455, table: 3, items: 4, total: 78.99, status: "Completed", color: "green", icon: FaCheck, iconBg: "bg-green-100", iconColor: "text-green-600" },
  { id: 12454, table: 12, items: 3, total: 55.25, status: "Pending", color: "orange", icon: FaClock, iconBg: "bg-orange-100", iconColor: "text-orange-600" },
];

const RecentOrdersCard = () => {
  return (
    <div className="flex flex-col col-span-full sm:col-span-12 bg-white dark:bg-gray-800 shadow-xs rounded-xl p-6">
      {/* Header */}
      <div className="flex items-center justify-between mb-6">
        <div className="flex items-center space-x-3">
          <div className="w-10 h-10 bg-linear-to-br from-green-400 to-green-600 rounded-lg flex items-center justify-center text-white">
            <FaReceipt size={20} />
          </div>
          <h2 className="text-xl font-bold text-gray-800 dark:text-gray-100">Recent Orders</h2>
        </div>
        <button className="px-4 py-2 rounded-lg text-blue-600 font-medium text-sm hover:bg-gray-100 dark:hover:bg-gray-700 flex items-center space-x-2">
          <span>View All Orders</span>
          <FaArrowRight />
        </button>
      </div>

      {/* Orders list */}
      <div className="space-y-4">
        {orders.map((order) => {
          const Icon = order.icon;
          return (
            <div
              key={order.id}
              className="bg-white dark:bg-gray-700 shadow rounded-lg p-4 flex items-center justify-between hover:shadow-lg transition-shadow"
            >
              <div className="flex items-center space-x-4">
                <div className={`${order.iconBg} w-12 h-12 rounded-lg flex items-center justify-center`}>
                  <Icon className={`${order.iconColor}`} size={18} />
                </div>
                <div>
                  <p className="font-semibold text-gray-800 dark:text-gray-100">Order #{order.id}</p>
                  <p className="text-xs text-gray-500">{`Table ${order.table} • ${order.items} items`}</p>
                </div>
              </div>
              <div className="text-right">
                <p className="font-semibold text-gray-800 dark:text-gray-100">${order.total.toFixed(2)}</p>
                <span className={`text-xs px-2 py-1 rounded-full bg-${order.color}-100 text-${order.color}-700`}>
                  {order.status}
                </span>
              </div>
            </div>
          );
        })}
      </div>
    </div>
  );
};

export default RecentOrdersCard;
