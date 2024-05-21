import { BrowserRouter as Router, Route, Routes} from 'react-router-dom';
import WelcomePage from './Components/WelcomePage/WelcomePage';
import AllPets from './Components/AllPets/AllPets';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<WelcomePage />} />
        <Route path="/all-pets" element={<AllPets />} />
      </Routes>
    </Router>
  );
}

export default App;
