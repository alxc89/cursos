package com.api.parkingcontrol.repositories;

import com.api.parkingcontrol.models.ParkingSpotModel;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.UUID;

//Passando como generics o model e o identificador da tabela.
@Repository
public interface ParkingSpotRepository extends JpaRepository<ParkingSpotModel, UUID> {

    boolean existsByLicensePlateCar(String LicensePlateCar);
    boolean existsByApartmentAndBlock(String apartment, String block);
    boolean existsByParkingSpotNumber(String parkingSpotNumber);
}
