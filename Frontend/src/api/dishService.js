import axios from "axios";

const api = axios.create({
  baseURL: "http://localhost:5000/api/dishes",
  headers: {
    "Content-Type": "application/json",
  },
});

/* ========== CRUD ========== */

const getAll = () => api.get("/");

const getById = (id) => api.get(`/${id}`);

const create = (data) => api.post("/", data);

const update = (id, data) => api.put(`/${id}`, data);

const remove = (id) => api.delete(`/${id}`);

export default {
  getAll,
  getById,
  create,
  update,
  remove,
};
