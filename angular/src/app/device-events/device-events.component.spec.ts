import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeviceEventsComponent } from './device-events.component';

describe('DeviceEventsComponent', () => {
    let component: DeviceEventsComponent;
    let fixture: ComponentFixture<DeviceEventsComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [DeviceEventsComponent],
        }).compileComponents();

        fixture = TestBed.createComponent(DeviceEventsComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
