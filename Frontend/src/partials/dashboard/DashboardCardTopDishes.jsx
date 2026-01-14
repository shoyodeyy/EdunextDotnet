import React from "react";
import { Link } from "react-router-dom";
import EditMenu from "../../components/DropdownEditMenu";

// Giả lập dữ liệu top món
const topDishes = [
  { id: 1, name: "Grilled Salmon", category: "Main Course", orders: 145, revenue: 3623, rating: 4.8 },
  { id: 2, name: "Chocolate Lava Cake", category: "Desserts", orders: 203, revenue: 1825, rating: 4.9 },
  { id: 3, name: "Bruschetta", category: "Appetizers", orders: 112, revenue: 840, rating: 4.7 },
  { id: 4, name: "Mushroom Risotto", category: "Main Course", orders: 98, revenue: 1813, rating: 4.6 },
];

const DashboardCardTopDishes = () => {
  return (
    <div className="flex flex-col col-span-full sm:col-span-12  bg-white dark:bg-gray-800 shadow-xs rounded-xl">
      {/* Header */}
      <div className="px-5 pt-5">
        <header className="flex justify-between items-start mb-4">
          <h2 className="text-lg font-semibold text-gray-800 dark:text-gray-100 mb-2">
            Top Selling Dishes
          </h2>
          {/* Menu button */}
          <EditMenu align="right" className="relative inline-flex">
            <li>
              <Link className="font-medium text-sm text-gray-600 dark:text-gray-300 hover:text-gray-800 dark:hover:text-gray-200 flex py-1 px-3" to="#0">
                Refresh
              </Link>
            </li>
            <li>
              <Link className="font-medium text-sm text-gray-600 dark:text-gray-300 hover:text-gray-800 dark:hover:text-gray-200 flex py-1 px-3" to="#0">
                Export
              </Link>
            </li>
            <li>
              <Link className="font-medium text-sm text-red-500 hover:text-red-600 flex py-1 px-3" to="#0">
                Remove
              </Link>
            </li>
          </EditMenu>
        </header>

        {/* Table */}
        <div className="overflow-x-auto">
          <table className="w-full text-left table-auto">
            <thead>
              <tr className="text-gray-600 dark:text-gray-400 text-sm border-b border-gray-200 dark:border-gray-700">
                <th className="py-2 px-3">#</th>
                <th className="py-2 px-3">Dish</th>
                <th className="py-2 px-3">Category</th>
                <th className="py-2 px-3">Orders</th>
                <th className="py-2 px-3">Revenue</th>
                <th className="py-2 px-3">Rating</th>
              </tr>
            </thead>
            <tbody>
              {topDishes.map((dish, index) => (
                <tr key={dish.id} className="hover:bg-gray-50 dark:hover:bg-gray-700 transition-colors cursor-pointer">
                  <td className="py-2 px-3 font-semibold">{index + 1}</td>
                  <td className="py-2 px-3 text-gray-800 dark:text-gray-100">{dish.name}</td>
                  <td className="py-2 px-3 text-gray-600 dark:text-gray-300">{dish.category}</td>
                  <td className="py-2 px-3 font-semibold text-gray-800 dark:text-gray-100">{dish.orders}</td>
                  <td className="py-2 px-3 font-semibold text-green-600 dark:text-green-400">
                    ${dish.revenue.toLocaleString()}
                  </td>
                  <td className="py-2 px-3 flex items-center text-gray-800 dark:text-gray-100">
                    <span className="mr-1">⭐</span>{dish.rating.toFixed(1)}
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
};

export default DashboardCardTopDishes;
