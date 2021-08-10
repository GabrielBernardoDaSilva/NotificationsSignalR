import React, { useState } from 'react'
import { Route } from 'react-router'
import Dashboard from './Pages/Dashboard'
import Info from './Pages/Info'


function App() {


  return (
    <div >
      <Route exact render={() =>(
        <>
          <Route exact path="/info" component={Info}/>
          <Route exact path="/dashboard" component={Dashboard}/>
        </>
      )}/>
        
  
    </div>
  )
}

export default App
