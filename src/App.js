import './App.css';
import { Navigation,Header, Services } from './Sections';
import { Part } from './Components';
import { ThemeProvider } from '@emotion/react';
import { createTheme } from '@mui/material';

const theme =createTheme(
{
  palette:
    {
      primary:
      {
        main: '#C52F91',
      }
    }
})

function App() {
  return (
    <ThemeProvider theme={theme}>
      <div>
        <Navigation/>
        {/* needs to be dynamic from here*/}
        <Header/>
        <Services/>
      </div>
    </ThemeProvider>
  );
}

export default App;
