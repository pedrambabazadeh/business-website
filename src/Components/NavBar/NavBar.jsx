import React, { useEffect } from 'react'
import {default as data} from './NavBarData'
import NavBarStructure from './NavBarStructure'
import './nav-bar.css'
export default function NavBar() {
  return (
    <NavBarStructure items={data}/>
  )
}
