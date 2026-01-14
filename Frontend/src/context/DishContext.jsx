import { createContext, useEffect, useState } from "react";
import dishService from "../api/dishService";


export const DishContext = createContext({
  dishes: [],
  addDish: () => {},
  updateDish: () => {},
  deleteDish: () => {},
  toggleStatus: () => {},
  selectedDishId: null,
  setSelectedDishId: () => {},
  notifications: [],
  removeNotification: () => {},
  notify: () => {},
});

export const DishProvider = ({ children }) => {
  const [dishes, setDishes] = useState([]);
  const [selectedDishId, setSelectedDishId] = useState(null);
  const [notifications, setNotifications] = useState([]);

  /* ========== TOAST ========== */
  const notify = (message, type = "info") => {
    const id = crypto.randomUUID();
    setNotifications((n) => [...n, { id, message, type }]);
    setTimeout(() => removeNotification(id), 4000);
  };

  const removeNotification = (id) => {
    setNotifications((n) => n.filter((x) => x.id !== id));
  };

  /* ========== API ========== */
  const fetchDishes = async () => {
    try {
      const res = await dishService.getAll();

      // normalize MongoDB _id -> id
      const normalized = res.data.map((d) => ({
        ...d,
        id: d._id || d.id,
      }));

      setDishes(normalized);
    } catch (err) {
      console.error(err);
      notify("Failed to load dishes", "error");
    }
  };

  const addDish = async (dish) => {
    try {
      await dishService.create(dish);
      notify("Dish added", "success");
      fetchDishes();
    } catch (err) {
      console.error(err);
      notify("Add dish failed", "error");
    }
  };

  const updateDish = async (id, data) => {
    try {
      await dishService.update(id, data);
      notify("Dish updated", "success");
      fetchDishes();
    } catch (err) {
      console.error(err);
      notify("Update failed", "error");
    }
  };

  const deleteDish = async (id) => {
    try {
      await dishService.remove(id);
      notify("Dish removed", "success");
      fetchDishes();
    } catch (err) {
      console.error(err);
      notify("Delete failed", "error");
    }
  };

  const toggleStatus = async (id) => {
    const dish = dishes.find((d) => d.id === id);
    if (!dish) return;

    await updateDish(id, {
      status: dish.status === "Available" ? "Unavailable" : "Available",
    });
  };

  useEffect(() => {
    const loadDishes = async () => {
      await fetchDishes();
    };
    loadDishes();
  }, []);

  return (
    <DishContext.Provider
      value={{
        dishes,
        addDish,
        updateDish,
        deleteDish,
        toggleStatus,
        selectedDishId,
        setSelectedDishId,
        notifications,
        removeNotification,
        notify,
      }}
    >
      {children}
    </DishContext.Provider>
  );
};
