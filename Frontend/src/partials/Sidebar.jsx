import React, { useState, useEffect, useRef } from "react";
import { NavLink, useLocation } from "react-router-dom";
import { FaTachometerAlt, FaUsers, FaCog } from "react-icons/fa";
import SidebarLinkGroup from "./SidebarLinkGroup";

const Sidebar = ({ sidebarOpen, setSidebarOpen }) => {
  const location = useLocation();
  const { pathname } = location;

  const trigger = useRef(null);
  const sidebar = useRef(null);

  const storedSidebarExpanded = localStorage.getItem("sidebar-expanded");
  const [sidebarExpanded, setSidebarExpanded] = useState(
    storedSidebarExpanded === null ? false : storedSidebarExpanded === "true"
  );

  // close on click outside
  useEffect(() => {
    const clickHandler = ({ target }) => {
      if (!sidebar.current || !trigger.current) return;
      if (!sidebarOpen || sidebar.current.contains(target) || trigger.current.contains(target)) return;
      setSidebarOpen(false);
    };
    document.addEventListener("click", clickHandler);
    return () => document.removeEventListener("click", clickHandler);
  });

  // close on esc
  useEffect(() => {
    const keyHandler = ({ keyCode }) => {
      if (!sidebarOpen || keyCode !== 27) return;
      setSidebarOpen(false);
    };
    document.addEventListener("keydown", keyHandler);
    return () => document.removeEventListener("keydown", keyHandler);
  });

  useEffect(() => {
    localStorage.setItem("sidebar-expanded", sidebarExpanded);
    if (sidebarExpanded) {
      document.body.classList.add("sidebar-expanded");
    } else {
      document.body.classList.remove("sidebar-expanded");
    }
  }, [sidebarExpanded]);

  // Menu items
  const menuItems = [
    { name: "Dashboard", icon: FaTachometerAlt, path: "/dashboard" },
    { name: "Management", icon: FaUsers, path: "/management" },
    { 
      name: "Settings", 
      icon: FaCog, 
      path: "/settings", 
      submenu: [{ name: "My Account", path: "/settings/account" }] 
    },
  ];

  return (
    <div className="min-w-fit">
      {/* Sidebar backdrop */}
      <div
        className={`fixed inset-0 bg-gray-900/30 z-40 lg:hidden lg:z-auto transition-opacity duration-200 ${
          sidebarOpen ? "opacity-100" : "opacity-0 pointer-events-none"
        }`}
      ></div>

      {/* Sidebar */}
      <div
        id="sidebar"
        ref={sidebar}
        className={`flex flex-col absolute z-40 left-0 top-0 lg:static lg:translate-x-0 h-dvh overflow-y-scroll no-scrollbar w-64 lg:w-20 lg:sidebar-expanded:w-64 shrink-0 bg-white dark:bg-gray-800 p-4 transition-all duration-200 ease-in-out ${
          sidebarOpen ? "translate-x-0" : "-translate-x-64"
        } rounded-r-2xl shadow-xs`}
      >
        {/* Header */}
        <div className="flex justify-between mb-10 pr-3 sm:px-2">
          <button
            ref={trigger}
            className="lg:hidden text-gray-500 hover:text-gray-400"
            onClick={() => setSidebarOpen(!sidebarOpen)}
          >
            <span className="sr-only">Close sidebar</span>
            <svg className="w-6 h-6 fill-current" viewBox="0 0 24 24">
              <path d="M10.7 18.7l1.4-1.4L7.8 13H20v-2H7.8l4.3-4.3-1.4-1.4L4 12z" />
            </svg>
          </button>
         <h1 className="text-2xl font-bold text-gray-800 dark:text-gray-100 transition-colors duration-300">Restaurant Admin</h1>
        </div>

        {/* Links */}
        <ul className="space-y-2">
          {menuItems.map((item) =>
            item.submenu ? (
              <SidebarLinkGroup key={item.name} activecondition={pathname.includes(item.path)}>
                {(handleClick, open) => (
                  <React.Fragment>
                    <a
                      href="#0"
                      onClick={(e) => { e.preventDefault(); handleClick(); setSidebarExpanded(true); }}
                      className={`block text-gray-800 dark:text-gray-100 truncate transition duration-150`}
                    >
                      <div className="flex items-center justify-between">
                        <div className="flex items-center">
                          <item.icon className={`shrink-0 ${pathname.includes(item.path) ? "text-violet-500" : "text-gray-400 dark:text-gray-500"}`} size={16} />
                          <span className="text-sm font-medium ml-4">{item.name}</span>
                        </div>
                        <div className={`flex shrink-0 ml-2 ${open && "rotate-180"}`}>
                          <svg className="w-3 h-3 fill-current text-gray-400 dark:text-gray-500" viewBox="0 0 12 12">
                            <path d="M5.9 11.4L.5 6l1.4-1.4 4 4 4-4L11.3 6z" />
                          </svg>
                        </div>
                      </div>
                    </a>
                    <div className={`lg:hidden lg:sidebar-expanded:block 2xl:block`}>
                      <ul className={`pl-8 mt-1 ${!open && "hidden"}`}>
                        {item.submenu.map((sub) => (
                          <li key={sub.name}>
                            <NavLink
                              end
                              to={sub.path}
                              className={({ isActive }) =>
                                "block text-sm font-medium transition duration-150 truncate " +
                                (isActive ? "text-violet-500" : "text-gray-500/90 dark:text-gray-400 hover:text-gray-700 dark:hover:text-gray-200")
                              }
                            >
                              {sub.name}
                            </NavLink>
                          </li>
                        ))}
                      </ul>
                    </div>
                  </React.Fragment>
                )}
              </SidebarLinkGroup>
            ) : (
              <li key={item.name}>
                <NavLink
                  end
                  to={item.path}
                  className={({ isActive }) =>
                    "flex items-center text-sm font-medium p-2 rounded transition duration-150 " +
                    (isActive ? "text-violet-500" : "text-gray-400 dark:text-gray-500 hover:text-gray-900 dark:hover:text-white")
                  }
                >
                  <item.icon className="shrink-0 mr-4" size={16} />
                  <span>{item.name}</span>
                </NavLink>
              </li>
            )
          )}
        </ul>

        {/* Expand / collapse button */}
        <div className="pt-3 hidden lg:inline-flex 2xl:hidden justify-end mt-auto">
          <button
            className="text-gray-400 hover:text-gray-500 dark:text-gray-500 dark:hover:text-gray-400"
            onClick={() => setSidebarExpanded(!sidebarExpanded)}
          >
            <span className="sr-only">Expand / collapse sidebar</span>
            <svg className={`shrink-0 fill-current text-gray-400 dark:text-gray-500 ${sidebarExpanded && "rotate-180"}`} xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 16 16">
              <path d="M15 16a1 1 0 0 1-1-1V1a1 1 0 1 1 2 0v14a1 1 0 0 1-1 1ZM8.586 7H1a1 1 0 1 0 0 2h7.586l-2.793 2.793a1 1 0 1 0 1.414 1.414l4.5-4.5A.997.997 0 0 0 12 8.01M11.924 7.617a.997.997 0 0 0-.217-.324l-4.5-4.5a1 1 0 0 0-1.414 1.414L8.586 7M12 7.99a.996.996 0 0 0-.076-.373Z" />
            </svg>
          </button>
        </div>
      </div>
    </div>
  );
};

export default Sidebar;
