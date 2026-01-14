import React, { useState } from "react";
import { useDish } from "../../hooks/useDish";

const CATEGORIES = ["Appetizers", "Main Course", "Desserts", "Beverages", "Specials"];

const DishForm = () => {
  const { addDish, notify } = useDish();

  const [name, setName] = useState("");
  const [price, setPrice] = useState("");
  const [status, setStatus] = useState("Available");
  const [category, setCategory] = useState("Main Course");

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!name || !price) {
      notify("Please fill in name and price", "error");
      return;
    }

    addDish({
      name,
      price: parseFloat(price),
      status,
      category,
      image: `https://source.unsplash.com/400x400/?food,${name}`,
    });

    // Reset form
    setName("");
    setPrice("");
    setStatus("Available");
    setCategory("Main Course");
  };

  return (
    <div className="flex flex-col col-span-full sm:col-span-6 bg-white dark:bg-gray-800 shadow-xs rounded-xl">
      {/* Card header */}
      <header className="px-5 py-4 border-b border-gray-100 dark:border-gray-700/60">
        <h2 className="font-semibold text-gray-800 dark:text-gray-100">Add New Dish</h2>
      </header>

      {/* Card body / form */}
      <div className="p-5">
        <form onSubmit={handleSubmit} className="space-y-4">
          {/* Dish Name */}
          <div>
            <label className="block text-gray-700 dark:text-gray-200 font-medium mb-1">
              Dish Name
            </label>
            <input
              type="text"
              placeholder="e.g. Truffle Pasta"
              value={name}
              onChange={(e) => setName(e.target.value)}
              className="w-full px-3 py-2 border border-gray-300 dark:border-gray-600 rounded-md bg-white dark:bg-gray-700 text-gray-900 dark:text-gray-200 placeholder-gray-400 dark:placeholder-gray-500 focus:outline-none focus:ring-2 focus:ring-sky-500"
            />
          </div>

          {/* Price & Category */}
          <div className="grid grid-cols-1 sm:grid-cols-2 gap-4">
            <div>
              <label className="block text-gray-700 dark:text-gray-200 font-medium mb-1">
                Price ($)
              </label>
              <input
                type="number"
                step="0.01"
                value={price}
                onChange={(e) => setPrice(e.target.value)}
                className="w-full px-3 py-2 border border-gray-300 dark:border-gray-600 rounded-md bg-white dark:bg-gray-700 text-gray-900 dark:text-gray-200 placeholder-gray-400 dark:placeholder-gray-500 focus:outline-none focus:ring-2 focus:ring-sky-500"
              />
            </div>

            <div>
              <label className="block text-gray-700 dark:text-gray-200 font-medium mb-1">
                Category
              </label>
              <select
                value={category}
                onChange={(e) => setCategory(e.target.value)}
                className="w-full px-3 py-2 border border-gray-300 dark:border-gray-600 rounded-md bg-white dark:bg-gray-700 text-gray-900 dark:text-gray-200 focus:outline-none focus:ring-2 focus:ring-sky-500"
              >
                {CATEGORIES.map((c) => (
                  <option key={c}>{c}</option>
                ))}
              </select>
            </div>
          </div>

          {/* Status */}
          <div>
            <span className="block text-gray-700 dark:text-gray-200 font-medium mb-1">
              Status
            </span>
            <div className="flex space-x-2">
              {["Available", "Unavailable"].map((s) => (
                <button
                  type="button"
                  key={s}
                  onClick={() => setStatus(s)}
                  className={`px-4 py-2 rounded-md font-medium ${
                    status === s
                      ? "bg-sky-500 text-white"
                      : "bg-gray-200 dark:bg-gray-700 text-gray-900 dark:text-gray-200"
                  }`}
                >
                  {s}
                </button>
              ))}
            </div>
          </div>

          {/* Submit */}
          <button
            type="submit"
            className="w-full py-2 px-4 bg-sky-500 hover:bg-sky-600 text-white font-semibold rounded-md shadow focus:outline-none focus:ring-2 focus:ring-sky-400"
          >
            Add to Menu
          </button>
        </form>
      </div>
    </div>
  );
};

export default DishForm;
