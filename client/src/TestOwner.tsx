import React, { useState, useEffect } from 'react';

interface Owner {
  id: number;
  name: string;
  email: string;
  phone: string;
  pets: string[]; // Assuming the pet names are strings for simplicity
}

const TestOwner: React.FC = () => {
  const [owners, setOwners] = useState<Owner[]>([]);
  const [loading, setLoading] = useState<boolean>(true);

  const fetchData = async () => {
    try {
      const response = await fetch('http://localhost:5098/api/Owner');
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      const jsonData = await response.json();
      setOwners(jsonData);
    } catch (error) {
      console.error('Error fetching data:', error);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchData();
  }, []);

  return (
    <div>
      {loading ? (
        <div>Loading...</div>
      ) : (
        <div>
          {owners.map((owner) => (
            <div key={owner.id} className="card">
              <h2>{owner.name}</h2>
              <p>Email: {owner.email}</p>
              <p>Phone: {owner.phone}</p>
              <p>Pets:</p>
              <ul>
                {owner.pets.map((pet, index) => (
                  <li key={index}>{pet}</li>
                ))}
              </ul>
            </div>
          ))}
        </div>
      )}
    </div>
  );
};

export default TestOwner;
