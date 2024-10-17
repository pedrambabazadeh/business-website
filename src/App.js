import './App.css';
import { Navigation,Header } from './Sections';
import { NumericCards } from './Components';

function App() {
  return (
    <div>
      <Navigation/>
      {/* needs to be dynamic from here*/}
      <Header/>
      <NumericCards/>
    </div>
  );
}

export default App;
