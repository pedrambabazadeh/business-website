import './App.css';
import { Navigation,Header } from './Sections';
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
        <Part title="test" data="new part is working successfully" color="#ffffff"/>
      </div>
    </ThemeProvider>
  );
}

export default App;
