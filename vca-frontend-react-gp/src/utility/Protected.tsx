import { ReactNode }from 'react'
import { Navigate } from 'react-router-dom'
import { authExist } from './util';

interface ProtectedProps {
  // isSignedIn: boolean;
  children: ReactNode;
}

function Protected({children }: ProtectedProps) {

  const is=authExist()
  if (!is) {
    return <Navigate to="/login" replace />;
  }
  return <>{children}</>;
}

export default Protected;




