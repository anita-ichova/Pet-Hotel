import React, { useEffect, useState } from 'react';

interface Pet {
  id: number;
  name: string;
  type: string;
  age: number;
}

function AllPets() {
  const [pets, setPets] = useState<Pet[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetch('http://localhost:5098/api/Pet')
      .then(response => response.json())
      .then(data => {
        setPets(data);
        setLoading(false);
      })
      .catch(error => {
        console.error('Error fetching pets:', error);
        setLoading(false);
      });
  }, []);

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <div>
      <h1>All Pets</h1>
      <ul>
        {pets.map(pet => (
          <li key={pet.id}>
            {pet.name} - {pet.type} - {pet.age} years old
          </li>
        ))}
      </ul>
    </div>
  );
}

export default AllPets;
