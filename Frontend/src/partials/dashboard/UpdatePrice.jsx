import React, { useState } from "react";
import { useDish } from "../../hooks/useDish";
import "../css/UpdatePrice.css";

const UpdatePrice = () => {
  const {
    selectedDishId,
    dishes,
    updateDish,
    setSelectedDishId,
  } = useDish();

  const selectedDish = dishes.find(d => d.id === selectedDishId);

  // ✅ derive initial state directly
  const [newPrice, setNewPrice] = useState(
    selectedDish ? String(selectedDish.price) : ""
  );

  // ✅ reset state ONLY when dish changes (no effect)
  if (!selectedDish) return null;

  const handleSave = () => {
    const price = parseFloat(newPrice);
    if (Number.isNaN(price)) return;

    updateDish(selectedDish.id, { price });
    setSelectedDishId(null);
  };

  const handleClose = () => {
    setSelectedDishId(null);
  };

  return (
    <div className="update-price">
      <div className="update-price__info">
        <img src={selectedDish.image} alt="" />
        <div>
          <span>Selected Item</span>
          <h3>{selectedDish.name}</h3>
        </div>
      </div>

      <div className="update-price__actions">
        <div className="price-input">
          <span>$</span>
          <input
            type="number"
            step="0.01"
            value={newPrice}
            onChange={(e) => setNewPrice(e.target.value)}
            autoFocus
          />
        </div>

        <button className="save" onClick={handleSave}>
          Save
        </button>

        <button className="close" onClick={handleClose}>
          ✕
        </button>
      </div>
    </div>
  );
};

export default UpdatePrice;
