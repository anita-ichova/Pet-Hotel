import React from 'react';
import { useNavigate } from 'react-router-dom';
import './WelcomePage.css';

function WelcomePage() {
  const navigate = useNavigate();

  const navigateTo = (path: string) => {
    navigate(path);
  };

  return (
    <div className="welcome-container">
      <h1>Welcome to Hotel for Pets</h1>
      <div className="button-group">
        <button onClick={() => navigateTo('/all-pets')}>All Pets</button>
        <button>Add Pet</button>
        <button>Add Owner</button>
        <button>All Owners</button>
      </div>
    </div>
  );
}

export default WelcomePage;
