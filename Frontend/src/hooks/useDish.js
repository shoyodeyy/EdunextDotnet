import { useContext } from "react";
import { DishContext } from "../context/DishContext";

export const useDish = () => {
  const ctx = useContext(DishContext);
  if (!ctx) throw new Error("useDish must be used inside DishProvider");
  return ctx;
};
