import React, { useEffect, useRef } from "react";
import { NavLink, useLocation } from "react-router-dom";
import { FaTachometerAlt, FaUsers, FaCog } from "react-icons/fa";
import SidebarLinkGroup from "./SidebarLinkGroup";

const Sidebar = ({ sidebarOpen, setSidebarOpen }) => {
  const { pathname } = useLocation();
  const trigger = useRef(null);
  const sidebar = useRef(null);

  // Click outside
  useEffect(() => {
    const clickHandler = ({ target }) => {
      if (!sidebar.current || !trigger.current) return;
      if (!sidebarOpen) return;
      if (sidebar.current.contains(target)) return;
      if (trigger.current.contains(target)) return;
      setSidebarOpen(false);
    };
    document.addEventListener("click", clickHandler);
    return () => document.removeEventListener("click", clickHandler);
  }, [sidebarOpen]);

  // ESC
  useEffect(() => {
    const keyHandler = (e) => {
      if (e.key === "Escape") setSidebarOpen(false);
    };
    document.addEventListener("keydown", keyHandler);
    return () => document.removeEventListener("keydown", keyHandler);
  }, []);

  const menuItems = [
    { name: "Dashboard", icon: FaTachometerAlt, path: "/dashboard" },
    { name: "Management", icon: FaUsers, path: "/management" },
    {
      name: "Settings",
      icon: FaCog,
      path: "/settings",
      submenu: [{ name: "My Account", path: "/settings/account" }],
    },
  ];

  return (
    <>
      {/* Backdrop mobile */}
      <div
        className={`fixed inset-0 bg-black/30 z-30 lg:hidden transition-opacity
        ${sidebarOpen ? "opacity-100" : "opacity-0 pointer-events-none"}`}
      />

      {/* Sidebar */}
      <aside
        ref={sidebar}
        className={`
        fixed lg:static z-40 top-0 left-0 h-screen
        w-64 min-w-[16rem] max-w-[16rem]
        bg-white dark:bg-gray-800
        shadow-lg
        transition-transform duration-200
        ${sidebarOpen ? "translate-x-0" : "-translate-x-full lg:translate-x-0"}
        `}
      >
        {/* Header */}
        <div className="flex items-center justify-between p-4 border-b border-gray-200 dark:border-gray-700">
          <h1 className="text-xl font-bold text-gray-800 dark:text-gray-100">
            Restaurant Admin
          </h1>

          <button
            ref={trigger}
            className="lg:hidden text-gray-500"
            onClick={() => setSidebarOpen(false)}
          >
            ✕
          </button>
        </div>

        {/* Menu */}
        <nav className="p-4">
          <ul className="space-y-2">
            {menuItems.map((item) =>
              item.submenu ? (
                <SidebarLinkGroup
                  key={item.name}
                  activecondition={pathname.includes(item.path)}
                >
                  {(handleClick, open) => (
                    <>
                      <button
                        onClick={handleClick}
                        className="w-full flex items-center justify-between text-gray-700 dark:text-gray-200"
                      >
                        <div className="flex items-center gap-3">
                          <item.icon size={16} />
                          <span className="text-sm font-medium">{item.name}</span>
                        </div>
                        <span className={`transition ${open && "rotate-180"}`}>
                          ▼
                        </span>
                      </button>

                      {open && (
                        <ul className="ml-6 mt-2 space-y-1">
                          {item.submenu.map((sub) => (
                            <li key={sub.name}>
                              <NavLink
                                to={sub.path}
                                className={({ isActive }) =>
                                  `text-sm ${
                                    isActive
                                      ? "text-violet-500"
                                      : "text-gray-500 hover:text-gray-800 dark:hover:text-gray-100"
                                  }`
                                }
                              >
                                {sub.name}
                              </NavLink>
                            </li>
                          ))}
                        </ul>
                      )}
                    </>
                  )}
                </SidebarLinkGroup>
              ) : (
                <li key={item.name}>
                  <NavLink
                    to={item.path}
                    className={({ isActive }) =>
                      `flex items-center gap-3 p-2 rounded
                      ${
                        isActive
                          ? "text-violet-500 bg-violet-50 dark:bg-gray-700"
                          : "text-gray-600 dark:text-gray-400 hover:bg-gray-100 dark:hover:bg-gray-700"
                      }`
                    }
                  >
                    <item.icon size={16} />
                    <span className="text-sm font-medium">{item.name}</span>
                  </NavLink>
                </li>
              )
            )}
          </ul>
        </nav>
      </aside>
    </>
  );
};

export default Sidebar;
