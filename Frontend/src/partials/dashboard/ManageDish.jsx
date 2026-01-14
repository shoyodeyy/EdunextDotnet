import React, { useState, useMemo } from "react";
import { useDish } from "../../hooks/useDish";

const ManageDish = () => {
  const {
    dishes,
    deleteDish,
    toggleStatus,
    selectedDishId,
    setSelectedDishId,
  } = useDish();

  const [searchTerm, setSearchTerm] = useState("");
  const [filterCategory, setFilterCategory] = useState("All");

  const filteredDishes = useMemo(() => {
    return dishes.filter((dish) => {
      const matchName = dish.name.toLowerCase().includes(searchTerm.toLowerCase());
      const matchCat = filterCategory === "All" || dish.category === filterCategory;
      return matchName && matchCat;
    });
  }, [dishes, searchTerm, filterCategory]);

  return (
    <div className="flex flex-col col-span-full sm:col-span-12 bg-white dark:bg-gray-800 shadow-xs rounded-xl">
      {/* Header */}
      <header className="px-5 py-4 border-b border-gray-100 dark:border-gray-700/60">
        <h2 className="font-semibold text-gray-800 dark:text-gray-100">Inventory Hub</h2>
        <p className="text-gray-500 dark:text-gray-400 text-sm">Control your items and availability</p>
      </header>

      {/* Filters */}
      <div className="p-5 flex flex-col sm:flex-row sm:items-center sm:justify-between gap-4">
        <input
          type="text"
          placeholder="Search dishes..."
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          className="px-3 py-2 border border-gray-300 dark:border-gray-600 rounded-md bg-white dark:bg-gray-700 text-gray-900 dark:text-gray-200 placeholder-gray-400 dark:placeholder-gray-500 focus:outline-none focus:ring-2 focus:ring-sky-500 w-full sm:w-1/3"
        />
        <select
          value={filterCategory}
          onChange={(e) => setFilterCategory(e.target.value)}
          className="px-3 py-2 border border-gray-300 dark:border-gray-600 rounded-md bg-white dark:bg-gray-700 text-gray-900 dark:text-gray-200 focus:outline-none focus:ring-2 focus:ring-sky-500 w-full sm:w-1/4"
        >
          <option value="All">All</option>
          <option value="Appetizers">Appetizers</option>
          <option value="Main Course">Main Course</option>
          <option value="Desserts">Desserts</option>
          <option value="Beverages">Beverages</option>
          <option value="Specials">Specials</option>
        </select>
      </div>

      {/* Table */}
      <div className="overflow-x-auto p-5">
        <table className="min-w-full divide-y divide-gray-200 dark:divide-gray-700">
          <thead>
            <tr className="bg-gray-50 dark:bg-gray-700">
              <th className="px-4 py-2 text-left text-xs font-medium text-gray-500 dark:text-gray-300 uppercase tracking-wider">Dish</th>
              <th className="px-4 py-2 text-left text-xs font-medium text-gray-500 dark:text-gray-300 uppercase tracking-wider">Category</th>
              <th className="px-4 py-2 text-left text-xs font-medium text-gray-500 dark:text-gray-300 uppercase tracking-wider">Price</th>
              <th className="px-4 py-2 text-left text-xs font-medium text-gray-500 dark:text-gray-300 uppercase tracking-wider">Status</th>
              <th className="px-4 py-2 text-right text-xs font-medium text-gray-500 dark:text-gray-300 uppercase tracking-wider">Actions</th>
            </tr>
          </thead>
          <tbody className="bg-white dark:bg-gray-800 divide-y divide-gray-200 dark:divide-gray-700">
            {filteredDishes.map((dish) => (
              <tr
                key={dish.id}
                className={selectedDishId === dish.id ? "bg-sky-50 dark:bg-gray-700 cursor-pointer" : "cursor-pointer"}
                onClick={() => setSelectedDishId(dish.id)}
              >
                <td className="px-4 py-2 flex items-center gap-2">
                  <img src={dish.image} alt={dish.name} className="w-10 h-10 rounded-md object-cover" />
                  <span className="font-medium text-gray-800 dark:text-gray-100">{dish.name}</span>
                </td>

                <td className="px-4 py-2">
                  <span className="px-2 py-1 text-xs rounded-full bg-gray-200 dark:bg-gray-700 text-gray-800 dark:text-gray-200">
                    {dish.category}
                  </span>
                </td>

                <td className="px-4 py-2 text-gray-800 dark:text-gray-100">
                  ${dish.price.toFixed(2)}
                </td>

                <td className="px-4 py-2">
                  <span
                    className={`px-2 py-1 rounded-full text-xs font-medium ${
                      dish.status === "Available"
                        ? "bg-green-100 text-green-800 dark:bg-green-700 dark:text-green-100"
                        : "bg-red-100 text-red-800 dark:bg-red-700 dark:text-red-100"
                    }`}
                  >
                    {dish.status}
                  </span>
                </td>

                <td className="px-4 py-2 text-right flex justify-end gap-2">
                  <button
                    className="px-3 py-1 bg-sky-500 text-white rounded-md text-sm hover:bg-sky-600"
                    onClick={(e) => {
                      e.stopPropagation();
                      toggleStatus(dish.id);
                    }}
                  >
                    Toggle
                  </button>
                  <button
                    className="px-3 py-1 bg-red-500 text-white rounded-md text-sm hover:bg-red-600"
                    onClick={(e) => {
                      e.stopPropagation();
                      deleteDish(dish.id);
                    }}
                  >
                    Delete
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>

        {filteredDishes.length === 0 && (
          <div className="text-center py-6 text-gray-500 dark:text-gray-400">
            No dishes found
          </div>
        )}
      </div>
    </div>
  );
};

export default ManageDish;
