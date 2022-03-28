import React from 'react';
import { BrowserRouter, Route, Routes } from "react-router-dom";

import Logon from './pages/Logon';
import UserRegister from './pages/Register/User';

export default function AppRoutes () {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Logon />}  />
                <Route path="/register" element={<UserRegister />} />
            </Routes>
        </BrowserRouter>       
    );
}
